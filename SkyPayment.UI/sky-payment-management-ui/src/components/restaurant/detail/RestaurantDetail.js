import React, {useEffect, useState} from "react";
import {useParams} from "react-router-dom";
import RestaurantService from "../../../services/RestaurantService";

function RestaurantDetail() {
    const {id} = useParams();
    const restaurantService = new RestaurantService();
    const [restaurant, setRestaurant] = useState();
    useEffect(()=>{
        restaurantService.getById(id).then((response) => {
            setRestaurant(response);
        })
    },[])

    return(
        <h1>{id}</h1>
    )
}

export default RestaurantDetail;