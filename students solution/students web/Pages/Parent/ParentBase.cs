using Dtos.Parent;
using System.Diagnostics;

namespace students_web.Pages.Parent
{
    public class ParentBase: ComponentBase
    {
        [Inject]
        public IParentService BaseParent { get; set; }

        public IEnumerable<ParentDto> Parents { get; set; }

        public ParentDto Parent { get; set; } = new ParentDto();

        public bool Visible { get; set; } = false;
        public string keyword { get; set; } = "";
        public bool DeleteSection { get; set; } = false;
        public int Current = 1;
        public int PageSize = 5;

        protected override async Task OnInitializedAsync()
        {
            await GetAll();
        }

        protected async Task GetAll()
        {

            Parents = await BaseParent.GetAll(Current, PageSize);
        }

        protected async Task Next()
        {
            if (Parents.Count() < PageSize)
            {

            }
            else
            {
                Current++;
                await GetAll();
            }
        }

        protected async Task Prev()
        {
            if (Current > 1)
            {
                Current--;
            }
            await GetAll();
        }

        protected void Edit(ParentDto row)
        {
            Visible = true;
            Parent = row;
        }


        protected async Task Add(ParentDto parent)
        {
            await BaseParent.Add(parent);
            Visible = false;
            Parents = await BaseParent.GetAll(Current, PageSize);
        }

        protected async Task Update(ParentDto parent)
        {
            await BaseParent.Update(parent);
            Visible = false;
            await GetAll();
        }

        protected async Task Delete(int id)
        {
            Visible = false;
            await BaseParent.Delete(id);
            await GetAll();
            DeleteSection = false;
        }

        protected async Task Search()
        {
            if(keyword == "")
            {
                await GetAll();
            }
            else
            {
                Parents = await BaseParent.Search(keyword, Current, PageSize);

            }
        }
    }
}
