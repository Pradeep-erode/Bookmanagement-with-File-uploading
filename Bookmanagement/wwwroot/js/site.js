// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $("#loginform").validate({
        rules:
        {
            admin:
            {
                required: true,
                maxlength: 20,
                letter: true
                
            },
            password:
            {
                required: true,
                number: true,
                maxlength:4,
                minlength:4

            }
        },
        messages:
        {
            admin:
            {
                required: "Admin username is required" 
            },
            password:
            {
                required: "Password is required",
                number:"Enter valid password",
                minlength:"Minimum 4"
            }
        }
    });
});
function SubmitDetails() {

    if ($("#loginform").validate())
    {
        
        $("#loginform").submit();
    }
}





$(function () {
    $("#bookaddform").validate({
        rules:
        {
            Title:
            {
                required: true,
                maxlength: 50
            },
            Author:
            {
                required: true
            },
            Price:
            {
                required: true,
                number: true
            }
        },
        messages:
        {
            Title:
            {
                required: "Give name of your book",
                maxlength:"max length 50 only"
            },
            Author:
            {
                required: "Please select Author"
            },
            Price:
            {
                required: "Price of book required",
                number:"Enter price in number"
            }

        }
    });
});

function SubmitDetails() {
    

    if ($("#bookaddform").validate()) {
        $("#bookaddform").submit();
    }
}