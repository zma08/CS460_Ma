$(document).ready(function ()
{
    $('#pirate').fadeOut(1000).fadeIn(3000);

    $('#booty').on('click', function (e) {
                
        $.ajax({
            type: 'GET',
            url: '/PS/Booty/',
            dataType: 'json',
            success: function (Data)
            {
                console.log("success:",Data);
                var str='';
                var tblstr;
                $.each(Data, function (i, item)
                {
                    str +='<tr><td class= "text-center text-danger">'+item.pirate+'</td><td class= "text-center text-danger">'+item.booty+'</td></tr>'
                });
                tblstr = '<table class="table-bordered:th"><tr><th class= "text-center text-danger">Name</th><th class= "text-center text-danger">Botty Total</th></tr>' + str + '</table>';
                $('#bootyDiv').html(tblstr);
            },
            error: function()
            {
                console.log("error: when loading");
            }
           
        });
        return false;
    });
    $(document).click(function () {
        $('#bootyDiv').html('');
    });
});
