namespace MvcState.Controllers
{
    public class SessionNoCookiesController : SessionLifecycleController
    {
        // Note: when we click a link : @Html.ActionLink("Click Me", "Index") it contains the session id.
        // As result "Is New?" is always true on Submit.

        // But submit form Html.BeginForm() has no session id until the page name is specified explicitly Html.BeginForm("Index").
        // As result "Is New?" is always false on link press and page refresh.
    }
}