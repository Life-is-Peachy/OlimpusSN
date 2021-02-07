var $emailInput = $('input#SignInEmail');
var $passwordInput = $('input#SignInPassword');
var $submitButton = $('input#SignInSubmit');

var $signInForm = $('#SignInForm');


$submitButton.on('mouseenter', function ()
{
    if ($emailInput.val().length < 5 || $passwordInput.val().length < 5)
    {
        $('.alert alert-warning').show();
    }
});



//$emailInput.keyup(function () 
//{
//    if ($(this).val().length >= 5 && $passwordInput.val().length >= 5) 
//    {
//        $submitButton.prop('disabled', false);
//    }
//});

