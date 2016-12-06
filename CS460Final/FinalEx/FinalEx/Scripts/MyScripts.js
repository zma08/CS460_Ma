$(document).ready(function () {
    $('#check').click(function () {
        

        $.ajax({
            type:'GET',
            url:'Home/Index/',
            dataType:'json',
            success: function (Data) {
                $('#show').show();
                $('#show').addClass("jumbotron"); $('#show').html("hi zhen");

                //var str = '';
                //var tblstr;
                //$.each(Data, function (i, item) {
                //    str += '<tr><td class= "text-center text-danger">' + item.pirate + '</td><td class= "text-center text-danger">' + item.booty + '</td></tr>'
                //});
                //tblstr = '<table class="table-bordered:th"><tr><th class= "text-center text-danger">Name</th><th class= "text-center text-danger">Botty Total</th></tr>' + str + '</table>';
                //$('#show').html(tblstr);
            }
            
        });
        return false;
    });

});
$(document).click(function () { $('#show').hide();});