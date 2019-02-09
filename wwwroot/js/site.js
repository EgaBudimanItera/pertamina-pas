﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//Simulasi
jQuery("#_clickProdukToInput").click(function () {

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

    jQuery("#listProdukToInput").append(
        "<div class='row'>" +
        "<input type='hidden' name='_idproduk' value=" + idproduk + " />" +
        "<input type='text' readonly name='namaproduk' value=" + namaproduk + " />" +
        "<input type='text' readonly name='jumlah' value=" + jumlah + " />" +
        "<input type='text' readonly name='satuan' value=" + satuan + " />" +
        "</div>"
    );

});

jQuery(".proses_jetty_1").click(function () {
   
    var idshipment = $(this).attr('id');
    var nojetty = $(this).attr('nojetty');
   
    jQuery.ajax({
        url: "/Home/Proses_jetty",
        data: 'idshipment='+idshipment+'&nojetty='+nojetty,
        type: "POST",
        //contentType: "application/json; charset=utf-8", // this
        dataType: "JSON",
        success: function (msg) {
            if (msg.success == false) {
                location.reload();
                alert("Gagal Karena Jetty 1 Sudah Ada Kapal Berlabuh");
            } else {
                
                location.reload();
            }
            
        }
    });
});

jQuery("#arrival_").change(function () {
    var _arrival = jQuery("#arrival_").val();
    var _idproduk = jQuery("#Idproduk").val();
    var _jumlah = jQuery("#Jumlah").val();

    
    if (_idproduk == "" || _jumlah == "") {
        alert("Silahkan pilih Produk dan Isi Jumlah Dahulu.");

    } else {
        var data = jQuery("#form_simulasi").serialize();
        var listproduk = jQuery("#listProdukToInput").serialize();
         
        jQuery.ajax({
            type: "POST",
            data: { data, listproduk },
            url: "/Simulasi/GetWaktu",
            
            dataType: "JSON",
            success: function (msg) {
                console.log(msg)
                jQuery("#berthed_").val(msg.berthed);
                jQuery("#comm").val(msg.comm);
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

jQuery(function ($) {
    $('.form-control.daritanggal').each(function () {
        var startDate = $(this).data("initial-datetime");
        $(this).datetimepicker({});
    });
});

jQuery.datetimepicker.setLocale('de');


