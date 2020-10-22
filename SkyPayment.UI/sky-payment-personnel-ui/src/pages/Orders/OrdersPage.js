import React, {useState} from "react";
import OrderList from "../../components/orders/OrderList";
import {HubConnection} from "signalr-client-react";

function OrdersPage(){
    const [orderList, setOrderList] = useState();
    const connection = new HubConnection('http://10.100.0.103:5000/personnelHub');
    connection.on('DenemeMesajı', data => {
        console.log(data);
    });
    connection.start();
    return(
        <OrderList orderList={orderList}/>
    )
}

export default OrdersPage;