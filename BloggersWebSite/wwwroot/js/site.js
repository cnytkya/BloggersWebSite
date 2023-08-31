// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
<script>
    function confirmDelete(id) {
        var confirmation = confirm("Bu içeriği silmek istediğinizden emin misiniz?");
    if (confirmation) {
        // Eğer kullanıcı onay verirse, silme işlemini gerçekleştir
        window.location.href = '/ControllerName/Delete/' + id;
        }
    }
</script>
