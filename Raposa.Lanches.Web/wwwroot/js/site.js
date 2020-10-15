
$("#addIngrediente").click(function () {
    
    if ($("#inputIngrediente").val() != 0) {


        $.ajax({
            url: "/Lanche/AdicionarIngrediente",
            type: 'post',

            data: {
                ID: $("#inputIngrediente").val()         
            },

            beforeSend: function () {                
                console.log("ENVIANDO...");
            }
        })
            .done(function (msg) {                
                console.log(msg);                

                $('#tbIngredientes')
                    .append(`<tr id=${msg.id}> <td> <input type="hidden" name="IngredientesIds" value="${msg.id}"/> ${msg.id} </td> <td> ${msg.nome} </td> <td> ${msg.valor} </td> <td> <a href="#" onclick="RemoveIngrediente(${msg.id})">Delete</a> </td> </tr>`);

            })

            .fail(function (msg) {
                console.log(msg);
            });

    } 
});


function RemoveIngrediente(id) {

    $(`table#tbIngredientes tr#${id}`).remove();    
}