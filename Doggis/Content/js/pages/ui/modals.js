$(function () {
    $('.js-modal-buttons .btn').on('click', function () {
        var color = $(this).data('color');
        var id = $(this).data('id');
        $('#mdModal .modal-content').removeAttr('class').addClass('modal-content modal-col-' + color);
        $('#mdModal .modal-content .confirmModal').attr('id', id);
        $('#mdModal').modal('show');
    });
});