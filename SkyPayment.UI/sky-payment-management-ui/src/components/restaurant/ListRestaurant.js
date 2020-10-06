import React from "react";
import {Button, Icon, Table} from "semantic-ui-react";

function ListRestaurant({restaurants, onAddRestaurant, onEditRestaurant, onDeleteRestaurant}) {
    console.log(restaurants);
    const mapped = restaurants.map(restaurant => (
        <Table.Row key={restaurant.id}>
            <Table.Cell>{restaurant.name}</Table.Cell>
            <Table.Cell>{restaurant.address}</Table.Cell>
            <Table.Cell>{restaurant.personnelCount}</Table.Cell>
            <Table.Cell>
                <Button onClick={()=>onEditRestaurant(restaurant.id)} primary>Düzenle</Button>
                <Button onClick={()=>onDeleteRestaurant(restaurant.id)} negative>Sil</Button>
            </Table.Cell>
        </Table.Row>
    ))
    return (
        <Table inverted style={{marginTop:0, borderRadius:0}}>
            <Table.Header>
                <Table.Row>
                    <Table.HeaderCell>İsim</Table.HeaderCell>
                    <Table.HeaderCell>Adres</Table.HeaderCell>
                    <Table.HeaderCell>Personel Sayısı</Table.HeaderCell>
                    <Table.HeaderCell>İşlemler</Table.HeaderCell>
                </Table.Row>
            </Table.Header>

            <Table.Body>
                {mapped}
            </Table.Body>
            <Table.Footer fullWidth>
                <Table.Row>
                    <Table.HeaderCell colspan='4'>
                        <Button
                            floated='right'
                            labelPosition='left'
                            primary
                            icon
                            size={"small"}
                            onClick={onAddRestaurant}
                        >
                            <Icon name='plus'/>
                            Restoran Ekle
                        </Button>
                    </Table.HeaderCell>
                </Table.Row>
            </Table.Footer>
        </Table>
    )
}

export default ListRestaurant;
