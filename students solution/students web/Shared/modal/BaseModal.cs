namespace students_web.Shared.modal
{
    public class BaseModal: ComponentBase
    {
        [Parameter]
        public bool visible { get; set; } = true;

        [Parameter]
        public RenderFragment ChildContent { get; set; }
        public RenderFragment ChildHeader { get; set; }

    }
}
