export default class BootstrapNavBarApplicationCustomizer

  extends BaseApplicationCustomizer<IBootstrapNavBarApplicationCustomizerProperties> {

 

    // These have been added

    private _topPlaceholder: PlaceholderContent | undefined;

    private _bottomPlaceholder: PlaceholderContent | undefined;

    @override

    public onInit(): Promise<void> {

        Log.info(LOG_SOURCE, `Initialized ${strings.Title}`);

        let cssURL = "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css  ";

        SPComponentLoader.loadCss(cssURL);

        SPComponentLoader.loadScript('https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js  ', {

        globalExportsName: 'jQuery'

      }).catch((error) => {

        console.log("jQuery loader error occurred");

      }).then(() => {

       return SPComponentLoader.loadScript("https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js  ");

      });

        // Added to handle possible changes on the existence of placeholders.

        this.context.placeholderProvider.changedEvent.add(this, this._renderPlaceHolders);

 

        // Call render method for generating the HTML elements.

            this._renderPlaceHolders();

            return Promise.resolve<void>();

    }

 

    private _renderPlaceHolders(): void {

 

      console.log('BootstrapApplicationCustomizer._renderPlaceHolders()');

      console.log('Available placeholders: ',

    this.context.placeholderProvider.placeholderNames.map(name => PlaceholderName[name]).join(', '));

     

      // Handling the top placeholder

      if (!this._topPlaceholder) {

    this._topPlaceholder =

      this.context.placeholderProvider.tryCreateContent(

        PlaceholderName.Top,

        { onDispose: this._onDispose });

     

    // The extension should not assume that the expected placeholder is available.

    if (!this._topPlaceholder) {

      console.error('The expected placeholder (Top) was not found.');

      return;

    }

     

    if (this.properties) {

      let topString: string = this.properties.Top;

      if (!topString) {

        topString = '(Top property was not defined.)';

      }

     

      if (this._topPlaceholder.domElement) {

        this._topPlaceholder.domElement.innerHTML = `

        <nav class="navbar navbar-inverse">

        <div class="container-fluid">

          <div class="navbar-header">

            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">

              <span class="icon-bar"></span>

              <span class="icon-bar"></span>

              <span class="icon-bar"></span>                       

            </button>

            <a class="navbar-brand" href="#">WebSiteName</a>

          </div>

          <div class="collapse navbar-collapse" id="myNavbar">

            <ul class="nav navbar-nav">

              <li class="active"><a href="#">Home</a></li>

              <li class="dropdown">

                <a class="dropdown-toggle" data-toggle="dropdown" href="#">Page 1 <span class="caret"></span></a>

                <ul class="dropdown-menu">

                  <li><a href="#">Page 1-1</a></li>

                  <li><a href="#">Page 1-2</a></li>

                  <li><a href="#">Page 1-3</a></li>

                </ul>

              </li>

              <li><a href="#">Page 2</a></li>

              <li><a href="#">Page 3</a></li>

            </ul>

            <ul class="nav navbar-nav navbar-right">

              <li><a href="#"><span class="glyphicon glyphicon-user"></span> Sign Up</a></li>

              <li><a href="#"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>

            </ul>

          </div>

        </div>

      </nav>`;

      }

    }

      }

    }

    private _onDispose(): void {

      console.log('[BootstrapApplicationCustomizer._onDispose] Disposed custom top and bottom placeholders.');

    }

}
