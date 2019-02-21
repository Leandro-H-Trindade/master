var countChecked = function () {
    var selected = $("input:checked").length;
    var $this = $(this);

    if (selected > 8) {
        $this.prop('checked', false);
        $('#erroModal .modal-body').html("Não é possível selecionar mais que 8 filmes.");
        $('#erroModal').modal('show');
    }
    else {
        $("#Selectedfilme").text(selected + " de 8 Filmes");
    }
};

countChecked();

$("input[type=checkbox]").on("click", countChecked);

$("button").click(function () {

    var selected = $("input:checked").length;

    if (selected === 8) {

        var filmesids = [];

        $.each($("input[type=checkbox]:checked"), function () {
            filmesids.push($(this).val());
        });

        $.post("/filmes/resultadocampeonato", { filmesids }, function (resultado) {
            window.location.href = "/filmes/Resultado";
        });
    }
    else {
        $('#erroModal .modal-body').html("selecione 8 filmes!");
        $('#erroModal').modal('show');
    }
});