import React from "react";
import EditRestaurant from "../../components/restaurant/EditRestaurant";

function EditRestaurantPage({selectedRestaurant}){
    const onSubmit = () => {};
    return(
        <EditRestaurant restaurant={selectedRestaurant} onSubmit={onSubmit}/>
    )
}

export default EditRestaurantPage;
