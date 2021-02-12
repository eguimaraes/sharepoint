<style>

#popupAmil{
display:none
}
</style>


<a id="popupAmil">
<img src='/pt/SiteAssets/sdac.png';> 
</a>



<script>

var element = document.createElement('div');
element.innerHTML = 'Hello World, I am the dialog content';


window.onload = (event) => {

var options = SP.UI.$create_DialogOptions();
options.title="        ";
options.width = 310;
options.height =300;
options.html=element 
SP.UI.ModalDialog.showModalDialog(options);


}

</script>
