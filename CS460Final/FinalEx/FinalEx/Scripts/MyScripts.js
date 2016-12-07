$(document).ready(function () {
    $('#Tesselation').click(function () {       

        $.ajax({
            type:'GET',
            url: 'Home/Art/',
            data: {data:'Tesselation'},
            dataType:'json',
            success: function (Data) {
                $('#show').show();
                $('#show').addClass("jumbotron");

                var str = '';
                var tblstr;
                $.each(Data, function (i, item) {
                    str += '<tr><td class= "text-center text-danger">' + item.ArtWork + '</td><td class= "text-center text-danger">' + item.Artist + '</td></tr>'
                });
                tblstr = '<table class="table-bordered:th"><tr><th class= "text-center text-danger">ArtWork</th><th class= "text-center text-danger">Artist</th></tr>' + str + '</table>';
                $('#show').html(tblstr);
            }
            
        });
        return false;
    });

    $('#Surrealism').click(function () {
        $.ajax({
            type: 'GET',
            url: 'Home/Art/',
            data: { data: 'Surrealism' },
            dataType: 'json',
            success: function (Data) {
                $('#show').show();
                $('#show').addClass("jumbotron");

                var str = '';
                var tblstr;
                $.each(Data, function (i, item) {
                    str += '<tr><td class= "text-center text-danger">' + item.ArtWork + '</td><td class= "text-center text-danger">' + item.Artist + '</td></tr>'
                });
                tblstr = '<table class="table-bordered:th"><tr><th class= "text-center text-danger">ArtWork</th><th class= "text-center text-danger">Artist</th></tr>' + str + '</table>';
                $('#show').html(tblstr);
            }

        });
        return false;
    });

    $('#Portrait').click(function () {


        $.ajax({
            type: 'GET',
            url: 'Home/Art/',
            data: { data: 'Portrait' },
            dataType: 'json',
            success: function (Data) {
                $('#show').show();
                $('#show').addClass("jumbotron");

                var str = '';
                var tblstr;
                $.each(Data, function (i, item) {
                    str += '<tr><td class= "text-center text-danger">' + item.ArtWork + '</td><td class= "text-center text-danger">' + item.Artist + '</td></tr>'
                });
                tblstr = '<table class="table-bordered:th"><tr><th class= "text-center text-danger">ArtWork</th><th class= "text-center text-danger">Artist</th></tr>' + str + '</table>';
                $('#show').html(tblstr);
            }

        });
        return false;
    });

    $('#Renaissance').click(function () {


        $.ajax({
            type: 'GET',
            url: 'Home/Art/',
            data: { data: 'Renaissance' },
            dataType: 'json',
            success: function (Data) {
                $('#show').show();
                $('#show').addClass("jumbotron");

                var str = '';
                var tblstr;
                $.each(Data, function (i, item) {
                    str += '<tr><td class= "text-center text-danger">' + item.ArtWork + '</td><td class= "text-center text-danger">' + item.Artist + '</td></tr>'
                });
                tblstr = '<table class="table-bordered:th"><tr><th class= "text-center text-danger">ArtWork</th><th class= "text-center text-danger">Artist</th></tr>' + str + '</table>';
                $('#show').html(tblstr);
            }

        });
        return false;
    });

    

});
$(document).click(function () { $('#show').hide();});