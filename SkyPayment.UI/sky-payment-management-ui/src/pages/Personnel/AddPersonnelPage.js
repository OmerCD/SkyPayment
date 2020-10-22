import React from "react";
import {Button, Dropdown, DropdownItem, Form, Label} from "semantic-ui-react";
import {useLocation} from 'react-router-dom';

const AddPersonnelComponent = ({restaurants, onCreate}) => {
    const mapped = restaurants.map(restaurant => {
        return {
            key: restaurant.id,
            text: restaurant.name,
            value: restaurant.id
        }
    })
    const onSubmit = (e) => {
        const formData = new FormData(e.target);
        const submitData = {};
        for (const pair of formData){
            submitData[pair[0]] = pair[1];
        }
        onCreate?.invoke(submitData);
    }
    return (
        <Form inverted onSubmit={onSubmit}>
            <Form.Group widths={"equal"}>
                <Form.Input label='İsim' placeholder='İsim' name='name'/>
                <Form.Input label='Soyisim' placeholder='Soyisim' name='lastName'/>
            </Form.Group>
            <Form.Group widths={"equal"}>
                <Form.Input label='Kullanıcı Adı' placeholder='Kullanıcı Adı' name='userName'/>
                <Form.Input label='E-Posta' placeholder='E-Posta' name='email'/>
            </Form.Group>
            <Form.Input label='Şifre' placeholder='Şifre' name='password'/>
            <Form.Field>
                <label>Restoran</label>
                <Dropdown label='Restoran' placeholder='Restoran Seçimi' selection options={mapped}
                          name='restaurantId'/>
            </Form.Field>
            <Button floated={"right"} primary>Ekle</Button>
        </Form>
    )
}

function AddPersonnelPage({onSubmit}) {
    const location = useLocation();
    const {restaurants} = location.state;
    return (
        <>
            <h1>Personel Ekleme</h1>
            <AddPersonnelComponent restaurants={restaurants} onCreate={onSubmit}/>
        </>
    )
}

export default AddPersonnelPage;