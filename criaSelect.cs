private void GetMenu()
        {
            HtmlGenericControl DivMenu = new HtmlGenericControl("div");
            DivMenu.Attributes.Add("id", "menuFrm");

            HtmlGenericControl TitleMenu = new HtmlGenericControl("span");
            TitleMenu.InnerHtml = "Selecione uma das views";

            DivMenu.Controls.Add(TitleMenu);

            


            HtmlGenericControl selMenu = new HtmlGenericControl("select");
            string[] views = getViewsMenu();

            foreach(string view in views)
            {

                HtmlGenericControl OptionMenu = new HtmlGenericControl("option");
                OptionMenu.InnerHtml = view;
                OptionMenu.Attributes.Add("value",Request.Url.AbsolutePath+ "?cccddd=" + view);
                OptionMenu.Attributes.Add("onchange", "location.href=this.value");
                selMenu.Controls.Add(OptionMenu);


            }



            DivMenu.Controls.Add(selMenu);
            AdicionaControle(DivMenu);



        }
