// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//Simulasi
jQuery("#_clickProdukToInput").click(function () {

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

    jQuery("#listProdukToInput").append(
        "<div class='row'>"+
            "<input type='hidden' name='idproduk[]' value=" + idproduk + " />" +
            "<input type='text' readonly name='namaproduk[]' value=" + namaproduk + " />" +
            "<input type='text' readonly name='jumlah[]' value=" + jumlah + " />" +
            "<input type='text' readonly name='satuan[]' value=" + satuan + " />" +
        "</div>"
    );

})