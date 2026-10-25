$(() => {
    var emailRequired = $('#ErrorEmailRequired').val();
    var emailInvalid = $('#ErrorInvalidEmail').val();
    var passwordRequired = $('#ErrorPasswordRequired').val();
    document.body.innerHTML = document.body.innerHTML.replace('data-val-required="1"', 'data-val-required="' + emailRequired + '"').replace('data-val-email="2"', 'data-val-email="' + emailInvalid + '"').replace('data-val-required="3"', 'data-val-required="' + passwordRequired + '"');

    const form = $('#login');
    form.removeData("validator");
    form.removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse(form);
    form.find("input").on("change", function () {
        $(this).valid();
    });
    form.removeAttr("novalidate");
    
    $('#submitButton').on('click', function () {
        document.forms['login'].submit();
    });
});