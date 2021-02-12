
<script>


var element = document.createElement('div');
element.innerHTML ="<a id='popupAmil' href='lll'><img src='das';></a>"


window.onload = (event) => {


var options = SP.UI.$create_DialogOptions();
options.title="        ";
options.width = 310;
options.height =300;
options.html=element;
SP.UI.ModalDialog.showModalDialog(options);
}



</script>
