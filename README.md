# ViewComponentBug

Here a short overview of the inner mechanics of this sample.

<ul>
    <li>
        There is a ScopeService. This ScopeService is registered as scoped inside the Startup Class. The function of this ScopeService is to hold a GUID.
    </li>
    <li>
        On asynchronous (ajax) calls from the index page the /home/component action is invoked. This action fills the ScopeService with a GUID. Then it assigns this GUID to a TestModel.TestGuid1 Property.
    </li>
    <li>
        Then this model is passed to a ViewComponent (TestViewComponent) using the ViewComponent method of the Controller
    </li>
    <li>
        Inside the TestViewComponent constructor, the ScopeService gets requested again.
    </li>
    <li>
        The Invoke Method of TestViewComponent then uses this service to get its GUID and assign it to TestModel.TestGuid2.
    </li>
    <li>
        In the View of the ViewComponent, both GUIDs of the model are displayed. Thos two GUIDs should always be the same! Since the ScopeService should be the same inside the request scope.
    </li>
</ul>
<p>
    If you run the application long enough and if the timing is right, you will see, that those GUID pairs sometimes differ from each other, and that one pair shows the GUIDs from another pair.<br />
    I did not study the ASP.NET Core code in detail, but since the await in the ViewComponentResult is gone, this bug happens.
</p>
