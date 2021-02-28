// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function CadastraInteresse()
{
  var parametros = {
    nome: $("#txtNome").val(),
    email: $("#txtEmail").val(),
    mensagem: $("#txtMensagem").val()
  };
  $.post("/Home/Cadastrar", parametros)
      .done(function(data){
        if(data.status == "OK")
        {
          $("#formCadastro").after("<h2>Ai sim heim, deu bom yuhuuuu...</h2>");
          $("#formCadastro").hide();
          $("#agenda").modal();
        }
        else
        {
          if(data.status == "ERR")
          {
            $("#formCadastro").after("<h2>" + data.mensagem+"</h2>");
          }
        }
        
        
  })
      .fail(function(){
        alert("Deu ruim heim !!!")
      });

}
$(document).ready(
    function(){
      $("#formCadastro").submit(function(e){
        e.preventDefault();
        CadastraInteresse();
    })
   }
  );