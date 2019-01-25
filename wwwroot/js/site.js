// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var NUMPRODUCT = 0;

//Simulasi
jQuery("#_clickProdukToInput").click(function (e) {
    e.preventDefault();
    jQuery("#listProdukToInput").show();
    var idproduk = jQuery("#Idproduk").val();
    var namaproduk = jQuery("#Idproduk option:selected").text();
    var jumlah = jQuery("#Jumlah").val();
    var satuan = jQuery("#Idsatuan option:selected").text();

    if (idproduk == "") {
        alert("Silahkan pilih Produk terlebih dulu.");
        return;
    }
    if (jumlah == "") {
        alert("Silahkan isi Jumlah Produk terlebih dulu.");
        return;
    }
    if (satuan == "") {
        alert("Silahkan pilih satuan Produk terlebih dulu.");
        return;
    }

    var productInput = '<div class="row"><div class="col-md-12"><div class="col-md-3"><input class="form-control" type="hidden" name="produk[' + NUMPRODUCT + '].produk" value="' + idproduk + '"><input type="text" readonly class="form-control" value="'+namaproduk+'"></div><div class="col-md-3"><input type="text" class="form-control" name="produk[' + NUMPRODUCT + '].jumlah" value="' + jumlah + '"></div></div></div>';
    jQuery("#listProdukToInput").append(
        productInput
    );
    NUMPRODUCT = NUMPRODUCT + 1;

});

jQuery("#arrival_").change(function () {
    var _arrival = jQuery("#arrival_").val();
    var _idproduk = jQuery("#Idproduk").val();
    var _jumlah = jQuery("#Jumlah").val();

    
    if (_idproduk == "" || _jumlah == "") {
        alert("Silahkan pilih Produk dan Isi Jumlah Dahulu.");

    } else {
        var data = jQuery("#form_simulasi").serialize();
        
        jQuery.ajax({
            type: "POST",
            data: data,
            url: "/Simulasi/GetWaktu",
            dataType: "json",
            success: function (msg) {
                console.log(msg)
                jQuery("#berthed_").val(msg.berthed);
                jQuery("#comm").val(msg.comm);
                jQuery("#comp").val(msg.comp);
                jQuery("#unberthed").val(msg.unberthed);
                jQuery("#departure").val(msg.departure);

                var ipt = msg.ipt.split(":");
                var h = ipt[0];
                var m = ipt[1];
                if (ipt[0] < 10) {
                    h = "0" + ipt[0];
                }
                if (ipt[1] < 10) {
                    m = "0" + ipt[1];
                }
                jQuery("#ipt").val(h + ":" + m);
            },
            error: function (err) {
                console.log(err)
            }
        });
    }

})


jQuery(function ($) {
    $('.form-control.arrival').each(function () {
        var startDate = $(this).data("initial-datetime");
        $(this).datetimepicker({});
    });
});
jQuery(function ($) {
    $('.form-control.berthed').each(function () {
        var startDate = $(this).data("initial-datetime");
        $(this).datetimepicker({});
    });
});