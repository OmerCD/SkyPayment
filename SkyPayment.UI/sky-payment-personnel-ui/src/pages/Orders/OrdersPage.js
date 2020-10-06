import React, {useState} from "react";
import OrderList from "../../components/orders/OrderList";

function OrdersPage(){
    const [orderList, setOrderList] = useState();
    return(
        <OrderList orderList={orderList}/>
    )
}

export default OrdersPage;