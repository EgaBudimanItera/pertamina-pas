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
    var satuan = jQuery("#Idsatuan").val();

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

    var productInput = '<div class="row"><div class="col-md-12"> '+
        '<div class="col-md-3" style="background:#5cb85c;border-top-left-radius:10px;border-bottom-left-radius:10px;padding:4px">' +
        '<input class="form-control" type="hidden" name="produk[' + NUMPRODUCT + '].produk" value="' + idproduk + '">' +
        '<input class="form-control" type="hidden" name="produk[' + NUMPRODUCT + '].satuan" value="' + satuan + '">' +
        '<input type="text" readonly class="form-control" value="' + namaproduk + '">' +
        '</div>' +
        '<div class="col-md-3" style="background:#5cb85c;border-top-right-radius:10px;border-bottom-right-radius:10px;padding:4px">' +
        '<input type="text" class="form-control" name="produk[' + NUMPRODUCT + '].jumlah" value="' + jumlah + '">' +
        '</div>' +
        '<div class="col-md-1" style="padding:4px"><button type="button" id="cekProyeksi" class="btn btn-danger">x</button></div>'+
        '</div ></div > ';
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
            }
        });
    }

})


jQuery("#berthed_").change(function () {
    var _arrival = jQuery("#arrival_").val();
    var _idproduk = jQuery("#Idproduk").val();
    var _jumlah = jQuery("#Jumlah").val();
    var data = jQuery("#form_simulasi").serialize();

    jQuery.ajax({
        type: "POST",
        data: data,
        url: "/Simulasi/GetWaktu2",
        dataType: "json",
        success: function (msg) {
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
        }
    });
    
    

})

jQuery("#_clickToProyeksi").click(function (e) {
    e.preventDefault();
    var dataform = jQuery('#listProdukToInput :input').serialize();
    var idasal = jQuery('#Idasal').val();
    var idtujuan = jQuery('#Idtujuan').val();
    var idkapal = jQuery('#Idkapal').val();
    var tgldatang = jQuery("#arrival_").val();
    var proses = jQuery('#Proses').val();
    var jamberangkat = jQuery("#departure").val();
    var tglberthed = jQuery("#berthed_").val();

    if (idkapal == '' || idasal == '' || idtujuan == '') {
        alert('Kapal, Asal dan Tujuan Harus di Isi.');
    }else {
        jQuery("#loader-proyeksi").show();
        if (proses == "Discharge") {
            jQuery("#result_proyeksi_stok_asal").hide();
            jQuery("#result_proyeksi_stok_tujuan").show();
            jQuery.ajax({
                url: "/Simulasi/Proyeksistoktujuandischarge",
                data: dataform + '&idpelabuhan=' + idtujuan + '&tgldatang=' + tgldatang + '&idtujuan=' + idasal + '&idkapal=' + idkapal + '&tglberthed=' + tglberthed,
                type: 'POST',
                dataType: 'JSON',
                success: function (res) {
                    jQuery("#loader-proyeksi").hide();
                    jQuery("#result_proyeksi_stok_tujuan").html(res.content);
                }
            })
        } else if (proses == "Loading") {
            jQuery("#result_proyeksi_stok_asal").show();
            jQuery("#result_proyeksi_stok_tujuan").show();

            jQuery.ajax({
                url: "/Simulasi/Proyeksistoktujuanloading",
                data: dataform + '&idpelabuhan=' + idtujuan + '&tgldatang=' + tgldatang + '&idtujuan=' + idasal + '&idkapal=' + idkapal + '&tglberthed=' + tglberthed + '&jamberangkat=' + jamberangkat,
                type: 'POST',
                dataType: 'JSON',
                success: function (res) {
                    jQuery("#loader-proyeksi").hide();
                    jQuery("#result_proyeksi_stok_tujuan").html(res.content);
                }
            })

            jQuery.ajax({
                url: "/Simulasi/Proyeksistokasalloading",
                data: dataform + '&idpelabuhan=' + idtujuan + '&tgldatang=' + tgldatang + '&idtujuan=' + idasal + '&idkapal=' + idkapal + '&tglberthed=' + tglberthed,
                type: 'POST',
                dataType: 'JSON',
                success: function (res) {
                    jQuery("#loader-proyeksi").hide();
                    jQuery("#result_proyeksi_stok_asal").html(res.content);
                }
            })
        }

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