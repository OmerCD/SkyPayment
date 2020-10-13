import React, {useState} from "react";
import {Form, Header} from "semantic-ui-react";

const MenuItem = ({index, name, price, onDeleteClicked}) => (
    <Form.Group>
        <Form.Input width={"10"} placeholder='İsim' name={'menuItemName' + index} itemName defaultValue={name}/>
        <Form.Input width={"6"} type='number' placeholder='Fiyat' name={'menuItemPrice' + index} itemPrice defaultValue={price}/>
        <Form.Button width={"1"} color={'red'} onClick={() => onDeleteClicked(index)}>Sil</Form.Button>
    </Form.Group>
)

function EditMenu({name, menuItemList, restaurants, onSubmit}) {
    const [menuItems, setMenuItems] = useState(menuItemList ?? [{id: 0}, {id: 1}, {id: 2}]);
    const [idCounter, setIdCounter] = useState(3);
    const deleteMenuItem = (id) => {
        const newItems = menuItems.filter(x => x.id !== id);
        setMenuItems(newItems);
    }
    const mappedMenuItems = menuItems.map(menuItem => {
        return (<MenuItem name={menuItem?.name} price={menuItem?.price} index={menuItem?.id}
                          onDeleteClicked={deleteMenuItem}/>)
    })
    return (
        <Form inverted>
            <Form.Group widths={"equal"}>
                <Form.Input label='Menü Adı' placeholder='Menü Adı'/>
                <Form.Button floated={"right"} onClick={addMenuItem}>Ürün Ekle</Form.Button>
            </Form.Group>
            <Header size={"large"} inverted>Ürünler</Header>
            {mappedMenuItems}
            <Form.Button type={'submit'} primaryyhg>Onayla</Form.Button>
        </Form>
    )

    function addMenuItem() {
        setMenuItems([...menuItems, {id: idCounter}]);
        setIdCounter(idCounter+1);
        console.log(menuItems);
    }
}

export default EditMenu;