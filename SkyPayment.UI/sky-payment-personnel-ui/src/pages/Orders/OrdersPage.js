import React, {useEffect, useState} from "react";
import OrderList from "../../components/orders/OrderList";
import {HubConnectionBuilder} from "@aspnet/signalr";

function OrdersPage(){
    const [orderList, setOrderList] = useState();
    const [hubConnection,setHubConnection] = useState( new HubConnectionBuilder().withUrl('http://10.100.0.103:5000/personnelHub').build());
    useEffect(()=>{
        // const connection = new HubConnection('http://10.100.0.103:5000/personnelHub');
        hubConnection.on('DenemeMesajı', data => {
            console.log(data);
        });
        hubConnection.start();
    },[])
    return(
        <OrderList orderList={orderList}/>
    )
}

export default OrdersPage;