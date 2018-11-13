# ASP.NET Core 2.0 with Rider 2018.2 and Visual Studio 2017

This document compares a developer's experience with an ASP.NET Core 2.0 application in two development environments: JetBrains Rider and Microsoft Visual Studio. For the purposes of providing an all-around, detailed comparison, the document walks through the various coding demos available in Scott Allen's [ASP.NET Core Fundamentals](https://app.pluralsight.com/library/courses/aspdotnet-core-fundamentals/table-of-contents) course (as of November 9, 2017) on Pluralsight.

The steps outlined were taken in Visual Studio 2017 15.7.4 (RTM) and various Rider 2018.2 pre-release builds.

<h2>Creating a new ASP.NET Core Web Application with C# (Empty template)</h2>

<h3>Observations: Rider :yellow_heart:</h3>
<ol>
    <li>In <em>New Solution</em> wizard, can't select a directory with the updated <em>Open File</em> dialog; have to
        enter path to parent directory manually in <em>Solution directory</em> text box; no recent directories
        available:<br><img src="images/new_solution_select_folder.png" width="600">
    </li>
    <li>Multimonitor support: Rider opened on display 1, <em>New Solution</em> wizard opened on display 2, then <em>Select
        Solution Directory</em> (<em>Open File</em>) opened on display 1 again
    </li>
    <li>Initial IDE layout:
        <ol>
            <li><em>Solution Explorer</em>'s solution node is collapsed (suboptimal),</li>
            <li><em>Scratches and Consoles</em> node is visible (suboptimal, doesn't relate to the created project);
            </li>
            <li>Text editor area is empty, contains generic keymap hints<br><img
                    src="images/solution_created_rider.png" width="600">
            </li>
        </ol>
    </li>
</ol>

<h3>Observations: Visual Studio :green_heart:</h3>
<ol>
    <li><em>Solution Explorer</em>:
        <ol>
            <li>Expanded to file level (good)</li>
            <li>Text editor area contains ASP.NET Code specific overview page with documentation links; <em>Connected
                Services</em> and <em>Publish</em> panes are available for navigation<br><img
                    src="images/solution_created_visual_studio.png" width="600">
            </li>
        </ol>
    </li>
    <li>Multimonitor support: all UI related to creating a project is opened on a single display</li>
</ol>

<h2>Initial run of the application that we've just created</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Accepted <em>Default</em> run configuration settings, built, ran.</p>
<p><em>Run</em> tool window says listening on port 5000, further requests going through the same port.</p>
<p>Browser not automatically opened - however, clicking the link from the <em>Run</em> window works to open
    in default browser.</p>
<p>Stopping is clear: works with <em>Ctrl+C</em> in the <em>Run</em> tool window, as well as with a <em>Stop
    Default</em> command.</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>All good. Built, ran using the default IIS Express launch profile. Output window showing output from
    ASP.NET Core Web Server, server says listening on port 17570, then requests going through a different
    port (54448) set in generated <em>applicationhost.config</em>, default browser (Chrome) automatically
    opened with the correct URL.</p>
<p>Links from the <em>Output</em> window can be <em>Ctrl</em>+clicked, which is a tiny bit worse than what
    Rider does.</p>
<p>Stopping is not clear: can't <em>Ctrl+C</em> in the <em>Output</em> window, and no Stop command is
    available in the <em>Debug</em> menu. The application can be either rerun from Visual Studio, or stopped
    using the separate IIS Express UI:<br><img width="600" src="images/iis_express_ui.png">
</p>

<h3>Notes, commits</h3>
<p>I assume that the differences in start/stop experience are due to Visual Studio <a
        href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/aspnet-core-module?view=aspnetcore-2.1">using
    IIS Express as a proxy</a> to Kestrel and Rider using Kestrel
    directly.
</p>

<h2>Opening and editing project file</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Project file can be opened in text editor via <em>F4</em> or via right-click &gt; <em>Edit &gt; Edit
    ....csproj</em>.</p>
<p>No <em>Quick Info</em> available on elements.</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Project file can be opened in text editor via right-click &gt; <em>Edit project file</em>.</p>
<p><em>Quick Info</em> tooltip is available on hover for valid <em>.csproj</em> elements:<br/>
    <img width="600" src="images/vs_csproj_quick_info.png">
</p>

<h2>Creating a configuration file (appsettings.json)</h2>

<h3>Observations: Rider :yellow_heart:</h3>
<p>Right-click project node &gt; <em>Add &gt; JSON file</em>. Just a generic JSON file template based on
    WebStorm. No predefined name, empty content.</p>

<h3>Observations: Visual Studio  :green_heart:</h3>
<p>Right-click project node &gt; <em>Add &gt; New Item </em>(or <em>Ctrl+Shift+A</em>)<em> &gt; ASP.NET Core
    &gt; ASP.NET Core Configuration File</em> (renamed to <em><u>App Settings File</u></em> in later VS
    versions). Provides a predefined name (<em>appsettings.json</em>), default file template contains a
    <code>ConnectionStrings: DefaultConnection</code> setting.<br>
    <img width="600" src="images/vs_appsettings_json.png">
</p>

<h2>Modifying Startup.cs to use a value from appsettings.json</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Good editing experience in JSON and C#. Import popup more useful than explicitly calling <em>Ctrl+.</em>
    in Visual Studio for importing a reference for <code>IConfiguration</code>.</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Good editing experience in JSON and C#. Complete Statement doesn't work in JSON though, and importing a
    reference for <code>IConfiguration</code> is less obvious/comfortable than in Rider.</p>

<h2>Creating and injecting a custom Greeter service instead of hardcoded settings value</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>All fine. Regular C# coding that involves Create from Usage and implementing interface members in a
    derived class.</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>All fine. Visual Studio handles Create from Usage and implementing interface members in a derived class,
    although not exactly as polished as Rider - good enough though:</p>
<ol>
    <li>Visual Studio does allow implementing <code>IGreeter</code> from usage when the <code>Greeter</code>
        class has been declared; however, Rider does have the advantage of providing the <em>Create derived
            type</em> context action upon the <code>IGreeter</code> declaration.
    </li>
    <li>VS create from usage isn't quite on par right now: given the undeclared <code>IGreeter</code>
        interface in method parameteres and the below line that uses an undeclared method,
        <ol>
            <li>The created symbol doesn't get focus: both when it's created in a separate file and when
                it's created in the same file</li>
            <li>Roslyn doesn't infer that the generated method should return a string, not an object
            </li>
        </ol>
    </li>
</ol>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/972408e215db8f217a500e7c7ee4ecfe8353eecf">Commit link</a></p>

<h2>Configuring middleware: using IApplicationBuilder</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Good enough. Regular C# editing with certain issues both in Rider and Visual Studio. For example, Rider's
    completion doesn't expect an identifier after the <code>async</code> keyword, so it starts to suggest
    weird classes, and this is where completion on space hurts: I wanted to type an unresolved symbol,
    <code>context</code>, but completion triggered on <em>Space</em> and inserted the unwanted
    <code>ContextBoundObject</code>
    class. Similar bad completion on unresolved symbol just below: wanted to use undeclared
    <code>logger</code> to add it as parameter later, but got <code>Logger&lt;&gt;</code> completed instead.
    See commit for details and context.</p>
<p>Additionally, Rider displays annoying Parameter Info tooltip in random spots inside the delegate:<br/><img
        width="600" src="images/rider_annoying_tooltip_with_delegates.png">
</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Good enough. Regular C# editing with certain issues both in Rider and Visual Studio. For example, VS
    completion breaks down after the <code>await</code> keyword - no longer suggests anything. Workaround:
    type a sync statement first, then add the <code>await</code> keyword. Rider handles this just fine. See
    commit for details and context.</p>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/ad558809904c44af3a7f2aa3242958896c805c30">Commit link</a></p>

<h2>Configuring middleware: showing exception details and configuring environment-specific middleware</h2>

<h3>Observations: Rider :yellow_heart:</h3>
<p>Good enough in terms of C# editing, although the "Use string interpolation" CA wasn't available when I
    needed it:</p>
<p><img width="600" src="images/rider_no_string_interpolation_ca.png">
</p>
<p>Rider doesn't pick environment or any other settings from <em>launchSettings.json</em> because it doesn't
    support launch settings: neither are they created with the ASP.NET Core template nor are they reflected
    in run configurations. Instead, environment variable settings in the default run configuration must be
    edited to switch to a different environment:<br><br><img width="600" src="images/rider_environment_variables_via_run_configuration.png">
</p>
<p>Creating <em>appsettings.Development.json</em>:</p>
<ol>
    <li>Creating via copy-paste of <em>appsettings.json</em> works a little better than in Visual Studio
        because Rider suggest entering a name for the copy before actually creating it, and then suggests
        adding the new file to Git.
    </li>
    <li>However, Rider doesn't by default nest <em>appsettings.Development.json</em> under <em>appsettings.json</em>
        as Visual Studio does. Had to click <em>File Nesting Settings</em> in the toolbar and manually enter
        a nesting rule: <em>parent: .json, child: .Development.json</em>.<br><img width="600"
                src="images/appsettings_nesting.png">
    </li>
</ol>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Good enough in terms of C# editing.</p>
<p>Launch settings are natively supported, as opposed to Rider.</p>
<p><em>appsettings.Development.json</em> was automatically nested under <em>appsettings.json</em> and didn't
    require any manual configuration.</p>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/032855d2ac63c7bdca103045f5da2b01cda12405">Commit
    link</a></p>
<p>Neither in Visual Studio nor in Rider was I able to replicate Scott's exercise with displaying a Greeting
    value from <em>appsettings.Development.json</em> for some reason - probably a configuration mishap on my
    side.</p>

<h2>Configuring middleware: serving static files</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>All good. Involves regular C# editing + creating an HTML file.</p>
<p>Live template for HTML file in Rider is slightly better as it places a hotspot at the value of the <code>&lt;title&gt;</code>
    tag, and then Rider suggests adding the new file to Git.</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p><span>All good. Involves regular C# editing + creating an HTML file.</span></p>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/94d61f8fd0dc0354b8d67350d5e3fed978edd977">Commit
        link</a></p>
<p>
    Along with creating an HTML file, Visual Studio removes a section that includes the <em>wwwroot</em> folder from the
    .<em>csproj</em> file. Rider doesn't do that. Unsure if this has any side effects so far.
</p>

<h2>Configuring middleware for ASP.NET MVC and adding a simple Home controller</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Viewing NuGet dependencies in Solution Explorer works fine. "Manage NuGet Packages" command is available
    in contextual menu for more nodes of the Dependencies tree than in Visual Studio, which is fine.</p>
<p>Adding a directory is easier in Rider as it can be done via <code>Alt+Insert</code>, along with adding
    new files.</p>
<p>Rider's lowerCamelCase and CamelCase completion matching is inferior to Visual Studio in simple cases
    like the below. Visual Studio suggest the expected <code>UseStaticFiles()</code> method matching <code>usf</code>;
    Rider suggests <code>UseDefaultFiles()</code> instead, both when matching with <code>usf</code> and
    <code>USF</code> (!!!!):<br/>
    <img width="600" src="images/camelcase_completion_vs.png">
    <br/>
    vs<br/>
    <img width="600" src="images/camelcase_completion_rider.png">
</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>Viewing NuGet dependencies in Solution Explorer works fine.</p>
<p>Adding a directory in Visual Studio is harder: for some reason, Visual Studio's "New folder" is only available as a
    separate contextual command, and not as an item in <em>Add New Item</em> (<code>Ctrl+Shift+A</code>).
</p>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/f6379b24491e9a60284adf7f3c242626dcc0b24a">Commit
        link</a></p>
        
<h2>Setting up conventional routing</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>All fine with C# editing and adding a new controller</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>All fine with C# editing and adding a new controller</p>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/3f4f74f725d9910d69567b156bb6226eb4adcab2">Commit link</a></p>

<h2>Setting up attribute routes</h2>

<h3>Observations: Rider :yellow_heart:</h3>
<p>Editing C# attributes works fine; however, import completion for the Route attribute is severely hanging:<br/>
    <img  width="600"
         src="images/rider_attribute_import_completion.png">
</p>
<h3>Observations: Visual Studio :green_heart:</h3>
<p>C# editing around attributes works as expected.</p>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/2373c1b43b144f22205b6a02f32ca42ce8b0db34">Commit link</a></p>

<h2>Action results: deriving from the <code>Controller</code> base class, modifying an
    action to return <code>IActionResult</code>, creating a <code>Restaurant</code> model, instantiating and
    returning the model instance from the controller
</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>All good in terms of editing C# in the controller and creating a new directory for models and a new model
    in it (tried using <em>Move</em> CA and refactoring)</p>

<h3>Observations: Visual Studio :green_heart:</h3>
<p>All good in terms of editing C# and creating a new directory and a new model (except that creating a new
    directory is a separate action - see one of the above Visual Studio notes)</p>

<h3>Notes, commits</h3>
<p><a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/f657b1f97da8ffbee2cd2dea2f3244b6c09c1117">Commit link</a></p>

<h2>Creating and rendering a view</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Rider is superior in this scenario: creating a view from usage (<code>return View(model);</code>) in the
    controller:</p>
<ol>
    <li>Creates the entire folder structure for views along with the actual view;</li>
    <li>The view is auto-typed with the model (if the model is provided) via a <code>@model</code>
        directive,
    </li>
    <li><code>@using</code> directives are automatically inserted, and a hotspot is placed at the bare
        HTML's <code>&lt;title&gt;</code> tag value.
    </li>
</ol>
<p><img width="600" src="images/rider_create_view_from_usage.png">
</p>
<p>One small hiccup is that when importing the model, FQN is used both in the model and in the using
    statement whereas it's only required in the using statement.</p>
<p>If a Razor view is created using a file template, the resulting view is more complete as well.</p>
<p>When manually typing a model (<code>@model Restaurant</code>), Rider auto-imports the model namespace;
    Visual Studio doesn't do this.</p>
<p>Rider makes Extend/Shrink Selection available in Razor views whereas Visual Studio doesn't.</p>
<p>Other than that, when using the imported model in the Razor markup, it's quite annoying that completion
    suggests <code>@model</code> when model is typed, even though the lower-case <code>@model</code> is only
    applicable as the import statement, and <code>@Model</code> should be provided instead.</p>

<h3>Observations: Visual Studio :yellow_heart:</h3>
<p>Visual Studio is lagging behind severely in this scenario:</p>
<ol>
    <li>You can't create a view from usage, at all.</li>
    <li>This means if you're creating the default initial folder structure for models, you have to create a
        directory twice (separate action), and then use <em>Add New Item</em> to create a view.
    </li>
    <li>In the view, Scott right away removes the default content and uses the html template to roll out a
        barebones HTML structure (this template isn't available in Rider but it's not needed there because
        Rider's default template for a Razor view is way better and already contains an HTML skeleton.
    </li>
</ol>
<p>When manually typing a model (<code>@model Restaurant</code>), Visual Studio doesn't suggest importing the model
    namespace - you need to manually type in an FQN.
</p>
<p>Visual Studio doesn't provide <em>Expand/Contract Selection</em> commands in Razor views.
</p>
<p>Visual Studio's completion only suggests the uppercase <code>@Model</code> property outside of the imports; however,
    it doesn't suggest anything when you type the lowercase <code>@model</code>, which means Rider's problem with
    suggested casing isn't as serious as it looks, because there's no typing habit for Rider completion to break when
    dealing with Visual Studio typing patterns.
</p>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/21a5fc3cdd024c69531d5805cd358d4e3b979801">Commit
        link</a></p>
        
<h2>Populating with data: creating a <em>Services</em> directory and moving
    <code>IGreeter</code> service there
</h2>

<h3>Observations: Rider :green_heart:</h3>
<p>Creating a new directory, again, is a bit easier. Rider modifies .csproj with a new folder include but
    Visual Studio doesn't do that: again, unclear differences in project model handling although it looks
    like Rider uses Visual Studio 2017's MSBuild distribution.</p>
<p>Moving <em>IGreeter.cs</em> to the new directory can be done with drag-n-drop, in which case VCS
    integration interprets the operation as a move (whereas the Visual Studio's d-n-d is seen as a file
    deletion + file addition). However, moving with drag-and-drop in Rider seems to introduce differences in
    line endings!</p>
<p>The better way to move <em>IGreeter.cs</em> to the new directory is certainly via Refactor This &gt; Move
    to Folder on the file node in Solution Explorer. Invoking the refactoring with default settings (that
    include fixing namespaces) just works. Good job:<br/>
    <img width="600" src="images/rider_move_to_folder.png">
</p>

<h3>Observations: Visual Studio :yellow_heart:</h3>
<p>Moving <em>IGreeter.cs</em> to the new <em>Services</em> directory by drag-n-drop in Solution Explorer.
    Requires updating the namespace in <code>IGreeter</code>, then compiling and going through several <em>CS0246</em>
    build errors to add a missing using directive in <em>Startup.cs</em>.</p>
<p>Subpar manual experience as Visual Studio doesn't have a <em>Move to Folder</em> refactoring (in fact, no
    <em>Move</em> refactorings at all, and no refactorings available on Solution Explorer nodes.)</p>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/d80c2e6cd303271aa9cda9b6c75439f156e82014">Commit
        link</a></p>

<h2>Creating new services: <code>IRestaurantData</code>,
    <code>InMemoryRestaurantData</code>, registering one of them in <em>Startup.cs</em>, modifying the Home
    controller to receive restaurant data from an <code>IRestaurantData</code> service, updating the view to
    accept an enumerable model and iterate through the collection of restaurants
</h2>

<h3>Observations: Rider :green_heart:</h3>
<ol>
    <li>Creating <code>IRestaurantData</code> via <em>Alt+Ins</em>: good, and again, Rider suggests to add
        the new file to Git right away.
    </li>
    <li>Declaring an interface member: <em>Complete Statement</em> at <code>GetAll{caret}</code> generates
        both the parentheses and the semicolon, Visual Studio doesn't do this.
    </li>
    <li>Creating <code>InMemoryRestaurantData</code> class: can be done with <em>Alt+Ins</em> but can also
        be done easier with a context action on <code>IRestaurantData</code> declaration to create a derived
        type:<br><img width="600" src="images/rider_create_derived_type.png"><br>
        Then, there's a quick-fix to implement the interface, and a context action to move to a separate file.
    </li>
    <li>Writing code in <code>InMemoryRestaurantData</code>: good. Notes:
        <ol>
            <li>Quick-fix <em>Initialize field from constructor</em> is available after declaring the
                <code>_restaurants</code> field:<br>
                <img width="600" src="images/rider_initialize_field_from_constructor.png"><br>However,
                the created constructor takes a list of restaurants as a parameter; what we need instead is
                a parameterless constructor with a field inside that is initialized with a new list. No
                context action or refactoring to convert parameter to field initialization, and the <em>Change
                    Signature</em> refactoring doesn't do that, too. No big deal to do this by hand though.
            </li>
            <li>Rider's code completion after the <code>new</code> keyword in collection initializer
                results in <code>new Restaurant()</code>, but the parentheses become redundant once braces
                are added for initializing properties. A typing assistant that removes redundant parentheses
                wouldn't hurt here.
            </li>
        </ol>
    </li>
    <li>Modifying the Home controller: great! Notes:
        <ol>
            <li>This time, after declaring a field and calling the <em>Initialize field from
                constructor</em> quick-fix, it does exactly what we want: declares a constructor with a
                <code>IRestaurantData</code> parameter. Nice!
            </li>
            <li>After modifying the parameter returned in <code>View()</code> to a collection of
                restaurants, Rider shows an error and suggests to modify the type of the view. Super
                nice!<br><img width="600" src="images/rider_change_view_model_type.png">
            </li>
        </ol>
    </li>
    <li>Modifying the Home view. Works, however:
        <ol>
            <li>No live template for an HTML table in Razor views. As a side note, there is one in HTML
                files handled by WebStorm, but it only generates a <code>&lt;table&gt;</code> tag pair, with
                no rows or cells inside - Visual Studio does better here.
            </li>
            <li>No <code>foreach</code> live template in Razor, only keyword completion - same as in Visual
                Studio. Also, no way to surround markup with braces.
            </li>
        </ol>
    </li>
</ol>

<h3>Observations: Visual Studio :yellow_heart:</h3>
<p>Visual Studio does it all fine actually; yellow here just means that Rider is significantly better during
    this coding segment.</p>
<ol>
    <li>Creating <code>IRestaurantData</code> via <em>Ctrl+Shift+A</em>: fine.</li>
    <li>Creating the derived <code>InMemoryRestaurantData</code> class: also has to be done with <em>Ctrl+Shift+A</em>
        because there's no action to create a derived type.
    </li>
    <li>Writing code in <code>InMemoryRestaurantData</code>: all fine, with a few notes:
        <ol>
            <li>When modifying the class declaration to implement <code>IRestaurant</code>, Visual Studio
                provides <em>Implement interface</em> and <em>Implement interface explicitly</em> quick
                actions. Nice.
            </li>
            <li>Scott creates a <code>InMemoryRestaurantData()</code> constructor with the <code>ctor</code>
                code snippet - nice, but that's the only option with VS as there's no context action on a
                field to initialize the field from constructor.
            </li>
        </ol>
    </li>
    <li>Modifying the Home controller: good. Notes:
        <ol>
            <li>Visual Studio doesn't have import items in completion, which means that when referencing an
                unimported type, you have to make sure to spell and capitalize it correctly, and then use a
                quick action to add an import. In Rider, import items are available in completion, which
                allows using camelHumps and abbreviations without being precise with naming, and
                additionally, accepting an import symbol suggestion adds the necessary using statement
                without the need to explicitly invoke a quick action.
            </li>
            <li>Visual Studio provides a set of quick actions to generate <code>_restaurantData</code> (as a
                full or read-only field, full or read-only property, local variable); as well as explicit
                actions to change <code>_restaurantData</code> to <code>IRestaurantData</code> or
                <code>restaurantData</code>:<br><img width="600" src="images/vs_generate_from_usage.png">
            </li>
        </ol>
    </li>
    <li>Modifying the Home view: good. Notes:
        <ol>
            <li>There's a <em>table</em> code snippet to generate an HTML table in Razor markup, nice.</li>
            <li>However, there's no <em>foreach</em> code snippet, just keyword completion.</li>
        </ol>
    </li>
</ol>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/47fe289c741a5e54340cdec78fdbc9918f7bdcdc">Commit
        link</a></p>

<h2>Creating and using a view model for the Index view</h2>

<h3>Observations: Rider :green_heart:</h3>
<ol>
    <li>Creating a directory and file for view model: good (both can be created from <em>Alt+Ins</em>, Git
        add suggestion.) Again, import items in completion rock!
    </li>
    <li>Modifying the controller: great. Initialize field from constructor rocks after declaring the
        <code>_greeter</code>
        field! <em>Use object initializer</em> is available both on constructor call and on further variable
        usages. The <em>Change view model type</em> quick-fix rocks again!
    </li>
    <li>Modifying the view: considerably better than Visual Studio (because the model type has already been
        changed for us, and because <code>Model</code> is resolved quicker, with valid completion
        suggestions available instantly.
    </li>
</ol>

<h3>Observations: Visual Studio :yellow_heart:</h3>
<p>Again, Visual Studio does a good job, it's just Rider that does it better.</p>
<ol>
    <li>Creating a directory and a file for the first view model: all fine.</li>
    <li>Modifying the controller: fine. <em>Initialize field from constructor</em> would be handy but it's not there. As
        a side note, Visual Studio now provides a quick action to use object initializer - the action is available from
        the constructor call only though, not from variable usages:<br/>
        <img width="600" src="images/vs_object_initialization.png">
    </li>
    <li>Modifying the view: decent. Had to change model type by hand, after which it took Visual Studio ~30 seconds to
        re-resolve the <code>Model</code> in <code>foreach</code>, figure out it's now a <code>HomeIndexViewModel</code>
        and finally start suggesting view model properties in code completion.
    </li>
</ol>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/fde46ac4973fc1a76ba70bcc3b2f6b1b0c3922c4">Commit
        link</a></p>

<h2>Creating a new Home controller action <code>Details(int id)</code>, updating services
    with a new <code>Get(int id)</code> method to return details for a particular restaurant, creating a simple
    <em>Details</em> view, updating the <em>Index</em> view to use tag helpers and creating a required <em>_ViewImports.cshtml</em>
    along the way.
</h2>

<h3>Observations: Rider :yellow_heart:</h3>
<p>Mixed result: Rider shines with a few great features in this segment but there's a bunch of bugs as
    well.</p>
<ol>
    <li>Creating a <code>Details(int id)</code> action in the Home controller: OK.
        <ol>
            <li>Similar code completion issues in Rider. Creating a method from usage works and also doesn't insert an
                implementation stub in the derived class; however, provides a placeholder to change the default return
                type from <code>object</code> to something else (<code>Restaurant</code>) in our case.
            </li>
            <li>A null check on model is easier to introduce with the <em>Check variable for null</em>
                context action that is conveniently available at the end of the statement; a quick path to
                null check pattern settings is provided, too - nice!<br>
                <img width="600" src="images/rider_check_variable_for_null.png">
            </li>
            <li>When returning <code>RedirectToAction("Index")</code>, Rider provides code completion for actions in
                the string literal that is passed over as parameter as well as navigation to action, nice!<br>
                <img width="600" src="images/rider_view_completion_in_string_literals.png"><br>
                Using <code>nameof(Index)</code> is a bit problematic due to a ReSharper bug (RSRP-469876) but if it's
                just typed in without completion, Rider actually continues to provide navigation to the view!<br>
                <img src="images/rider_navigation_to_action_with_nameof.png">
            </li>
            <li>When returning a View(model), Rider detects that the referenced view is missing and suggests to create
                it:<br>
                <img width="600" src="images/rider_create_razor_views.png">
            </li>
        </ol>
    </li>
    <li>Updating services with a new <code>Get(int id)</code> method: fine. There actually is a (poorly discoverable)
        context action to implement the new interface method in derived classes:<br>
        <img width="600" src="images/rider_implement_in_derived_classes.png"><br>
        Good to know it's here but I'd expect a quick-fix instead. All in all, fine editing in both services.
    </li>
    <li>
        Creating the <em>Details</em> view: good, with a few quirks!
        <ol>
            <li>
                Created with a quick-fix from controller (see above) - nice!
            </li>
            <li>
                However, model completion suggests an unqualified <code>Restaurant</code> type, which then triggers an
                import action, and all that ends up with FQNs in both <code>@using</code> and <code>@model</code>
                directives - which, in turn, requires removing FQN from the <code>@model</code> directive with a
                quick-fix. Also, the file template's active hotspot in the <code>&lt;title&gt;</code> tag prevents from
                calling <em>Alt+Enter</em> on the <em>@model</em> directive - you need to fill the hotspot first of all.
            </li>
            <li><code>ModelExpressionProvider</code> annoys as the first completion suggestion for both
                <code>@mod</code> and <code>@Mod</code> - should be <code>@Model</code> instead!
            </li>
            <li>Trying to write a tag helper but there's no completion for asp-* attributes and their values. This is
                because there's no <em>_ViewImports.cshtml</em>, and Rider doesn't provide a quick-fix to create one!
            </li>
            <li>However, after creating <em>_ViewImports.cshtml</em> (see next step), Rider starts to provide completion
                for both tag helper attributes (<code>asp-action</code> and such) and their values, nice!<br>
                <img width="600" src="images/rider_completion_tag_helper_values.png">
            </li>
        </ol>
    </li>
    <li>Creating <em>_ViewImports.cshtml</em>: with hiccups as there's no cshtml items in <em>Alt+Ins</em> on the <em>Views</em>
        folder (only on nested folders). Workaround: use a generic File file template. After creating <em>_ViewImports.cshtml</em>,
        there are no completion suggestions for assembly name in Rider, just like in Visual Studio :( - completion for
        the <code>@addTagHelper</code> directive is available though.
    </li>
    <li>Modifying the <em>Index</em> view to render links to restaurant details using 3 different kinds of syntax: fine,
        with a few hiccups:
        <ol>
            <li>When entering the regular anchor with relative paths, Rider complains it doesn't recognize the relative
                path, suggests to set path mapping, then nothing happens but the inspection is gone. Trying to edit path
                mappings fails silently:<br/>
                <img width="600" src="images/rider_path_mapping.png">
            </li>
            <li>Action link syntax: again, action resolve in string parameter; however, completion can be
                improved:<br>
                <img width="600" src="images/rider_completion_actionlink.png">
            </li>
            <li>Tag helper syntax: good! Rider even suggests asp-route-id that is derived from the Details action
                signature - something that Visual Studio doesn't do:<br>
                <img width="600" src="images/rider_completion_asp_route_id.png">
            </li>
        </ol>
    </li>
</ol>

<h3>Observations: Visual Studio :yellow_heart:</h3>
<p>Visual Studio does the job but overall in a lot less intelligent way than Rider.</p>
<ol>
    <li>Creating a <code>Details(int id)</code> action in the Home controller: decent.
        <ol>
            <li>Some code completion issues in Visual Studio when using a new method <code>Get(id)</code>
                before declaring it; creating the method in the interface from usage works (doesn't insert
                an implementation stub in the derived <code>InMemoryRestaurantData</code> though).
            </li>
            <li>Returning <code>RedirectToAction("Index")</code> works but Visual Studio doesn't provide
                code completion for actions in the string literal, and Scott prefers to use <code>nameof(Index)</code>
                instead; when returning a <code>View(model)</code>.
            </li>
            <li>Visual Studio doesn't see that the view doesn't exist and doesn't suggest to create one.
            </li>
        </ol>
    </li>
    <li>Updating services with a new <code>Get(int id)</code> method: fine. When going to the derived <code>InMemoryRestaurantData</code>,
        Visual Studio does provide a quick action to implement the new interface method.
    </li>
    <li>Creating the <em>Details</em> view: OK. No completion for controller and action names in tag helpers
        though.
    </li>
    <li>Creating <em>_ViewImports.cshtml</em>: OK, using a specialized item via <em>Ctrl+Shift+A</em>.
        However, Visual Studio provides no completion for the assembly name refrenced from <em>_ViewImports.cshtml</em>.
    </li>
    <li>Modifying the <em>Index</em> view to render links to restaurant details using 3 different kinds of
        syntax: <code>&lt;a href&gt;</code>, <code>@Html.ActionLink</code> and a tag helper. Visual Studio
        provides completion for tag helper attributes but, again, there's no code completion for controller
        and view names in string literals - only for C# symbols after <code>@</code>.
    </li>
</ol>

<h3>Notes, commits</h3>
<p>
    <a href="https://github.com/gorohoroh/rider-visual-studio-asp.net-core-fundamentals/commit/ddc5a0ebabab97464050d15219bfe3c4ea143615">Commit
        link</a></p>