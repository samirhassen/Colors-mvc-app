$(function () {
    $("#colors-table").on('click', ".colors-table-row", function () {
        $this = $(this);
        var clonedDescDiv = $this.find(".full-desc").clone();
        //eftersom att jquery ui dialog flyttar annars på
        //diven som blir till en dialog, varför find inte hittar den andra gången
        clonedDescDiv.dialog({
            title: "Additional Description",
            modal: true,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                }
            }
        });

        $this.attr("data-order", function (i, val) {
            return parseInt(val) + 1;
        });

        var sortedDivs = $("#colors-table-body .colors-table-row").sort((a, b) => $(a).data("order") - $(b).data("order"))
        $("#colors-table-body").html(sortedDivs);
    })
});