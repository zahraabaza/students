using students_Api.Extenstions;
using students_Api.Helpers;

namespace students_Api.Controllers;
public class BaseGenericAPIController<TEntity, TAddDto, TReturnDto> : BaseAPIController
    where TEntity : BaseEntity
    where TAddDto: BaseDto
    where TReturnDto : BaseDto
{
    private readonly IBaseRepository<TEntity> _Repo;
    private readonly IUnitOfWork _uow;

    public BaseGenericAPIController(IUnitOfWork uow)
    {
        _uow = uow;
        _Repo = _uow.BaseRepository<TEntity>();
    }


    [HttpPost("add")]
    public virtual async Task<IActionResult> Add(TAddDto dto)
    {
        dto.Id = 0;

        var x = _uow.Mapper.Map<TEntity>(dto);

        var result = _Repo.Add(x);

        if (!await _uow.SaveAsync()) return BadRequest(400);

        var map = _uow.Mapper.Map<TReturnDto>(result);

        return Ok(map);
    }

    protected virtual async Task<IActionResult> Add(TEntity entity)
    {
        var result = _Repo.Add(entity);

        if (!await _uow.SaveAsync()) return BadRequest(400);

        var map = _uow.Mapper.Map<TReturnDto>(result);

        return Ok(map);
    }

    [HttpPut("update")]
    public virtual async Task<IActionResult> Update(TAddDto dto)
    {
        var entity = await _Repo.GetByAsync(x => x.Id == dto.Id);

        if (entity == null || entity.IsDeleted) return NotFound(StatusCodes.Status404NotFound);

        var result = _uow.Mapper.Map(dto, entity);

        _Repo.Update(result);

        if (await _uow.SaveAsync()) return Ok();

        return BadRequest("Failed to Update");
    }

    protected virtual async Task<IActionResult> Update(TEntity entity)
    {
        _Repo.Update(entity);

        if (!await _uow.SaveAsync()) return BadRequest("Failed to Update");

        return Ok(entity);

    }

    [HttpDelete]
    public virtual async Task<IActionResult> Delete(int id)
    {
        var entity = await _Repo.GetByAsync(x => x.Id == id );

        if (entity == null || entity.IsDeleted) return NotFound(StatusCodes.Status404NotFound);

        entity.IsDeleted = true;

        _Repo.Update(entity);

        if (!await _uow.SaveAsync()) return BadRequest(StatusCodes.Status400BadRequest);

        return Ok(entity);

    }

    protected virtual async Task<IActionResult> Delete(TEntity entity)
    {
        entity.IsDeleted = true;
        _Repo.Update(entity);

        if (!await _uow.SaveAsync()) return BadRequest("Failed to Delete");

        return Ok(entity);
    }

    [HttpGet]
    public virtual async Task<IActionResult> Get([FromQuery] UserParams userParams)
    {
        var result = await _Repo.Map_GetAllAsync<TReturnDto>(userParams);

        Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);

        return Ok(result);
    }
    
    [HttpGet("GetAll")]
    public virtual async Task<IActionResult> Get()
    {
        var result = await _Repo.Map_GetAllAsync<TReturnDto>();


        return Ok(result);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        // var cityId = _hashids.Decode(id)[0];

        var result = await _Repo.Map_GetByAsync<TReturnDto>(x => x.Id == id );

        return Ok(result);
    }
}
