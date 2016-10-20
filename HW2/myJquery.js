function cal(){
    if(isNaN($("#purchase").val()) || isNaN($("#down").val()) || $("#purchase").val()=="" || $("#down").val()=="" || parseFloat(($("#purchase").val()) ) < parseFloat(($("#down").val())) ) {
        alert("input number only & purchase price has to be greater than down payment.");
    }
    else{
        var dn = parseFloat($("#down").val());
        var pur = parseFloat($("#purchase").val());
        var prin = pur - dn;
        var n = parseFloat($("input[type='radio']:checked").val());
        //alert("You selected "+n+" year fixed");
        var r= checkRate(n) ;
        //alert("Your rate is "+(r*100).toFixed(2)+"%");
        var payment = prin*(r/12)*( Math.pow( (1+r/12),n*12) )/((Math.pow((1+r/12),n*12))-1);
        
        var tableString = `
            <table class="center table table-border table-hover">
                <tr>
                    <th scope="col"></td>
                    <th class="center" scope="col">`+n+` yr fixed</td>
                    
                </tr>
                <tr>
                    <th scope="row">Payment</th>
                    <td class="center">$`+payment.toFixed(2)+`</td>
                </tr>  
                <tr>
                    <th scope="row">Interest Rate</th>
                    <td class="center">`+(r*100).toFixed(2)+`%</td>
                </tr> 
            </table>`
        
        $("#blank").append(tableString);;
    }
}
                            
function checkRate(field){
    var r;
    if(field==15){
                r=0.0275;
                }
        if(field==30){
                r=0.0350;
            }
    return r;
    
}



$("input[type='radio']").click(function(){ 
        $("#termString").html("<span class='red1'>confirm:<br/>Loan term: "+parseFloat($("input[type='radio']:checked").val())+" years.<br/>Purchase Price: $"+$("#purchase").val()+"<br/> Down Payment: $"+$("#down").val()+"</span>");});



$("#sub").click(function(){
                          
                          if( $("input[type='radio']:checked").length>0)
                          {
                          $("#head").html("Your Payment below").css("background-color","grey");  
                          $("div#blank").empty();
                          cal();   
                          $("<a id='set' href='https://www.bankofamerica.com/mortgage/home-mortgage/' target='_blank'>need more info? click me.</a>").appendTo("div#blank");
                          }
                          else{
                              alert("Select a loan term Please...");
                          } });
                          

