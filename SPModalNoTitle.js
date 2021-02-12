<style type="text/css">
body div.ms-dlgBorder div.ms-dlgTitle
{
    display:none;
}   
</style>

<script>

window.onload = (event) => {

var options = SP.UI.$create_DialogOptions();

options.title="";
options.width = 310;
options.height =300;
options.url = "/pt/SiteAssets/sdf.png";
SP.UI.ModalDialog.showModalDialog(options);


}

</script>
