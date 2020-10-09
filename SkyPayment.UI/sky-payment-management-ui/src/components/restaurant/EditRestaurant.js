import React from "react";
import {Form} from "semantic-ui-react";

function EditRestaurant({restaurant, onSubmit}) {
    const handleSubmit = ({target}) => {
        const formData = new FormData(target);
        const newRestaurant = {id: restaurant?.id ?? 0};
        for (const pair of formData.entries()) {
            newRestaurant[pair[0]] = pair[1];
        }
        console.log(newRestaurant);
        if (onSubmit) {
            onSubmit(newRestaurant);
        }
    }
    return (
        <Form onSubmit={handleSubmit}>
            <Form.Field>
                <input name={"name"} placeholder={"Restoran Adı"} defaultValue={restaurant?.name}/>
            </Form.Field>
            <Form.Field>
                <input type={"number"} name={"tableCount"} placeholder={"Masa Sayısı"} defaultValue={restaurant?.tableCount}/>
            </Form.Field>
            <Form.Button type={'submit'}>Onayla</Form.Button>
        </Form>
    )
}

export default EditRestaurant;
