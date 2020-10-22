import React from "react";
import {Button, Icon, Menu, Segment, Table} from "semantic-ui-react";
import {useAppSettings} from "../../context/AppSettingsContext";

function ListRestaurant({restaurants, onAddRestaurant, onEditRestaurant, onDeleteRestaurant, onMenusClick, onPersonnelClick, onDetailClick}) {
    // const tableHeight = `calc(100vh - ${useAppSettings().navbarHeight})`
    const TableCell = ({children}) => (
        <Table.Cell style={{height: '54px'}}>
            {children}
        </Table.Cell>
    )
    const mapped = restaurants.map(restaurant => (
        <Table.Row key={restaurant.id} >
            <TableCell>{restaurant.name}</TableCell>
            <TableCell>{restaurant.address}</TableCell>
            <TableCell>{restaurant.personnelCount}</TableCell>
            <TableCell>
                {/*<Button style={{width:'125px'}} onClick={() => onEditRestaurant(restaurant.id)} primary>Düzenle</Button>*/}
                {/*<Button style={{width:'125px'}} onClick={() => onMenusClick(restaurant.id)} color={"facebook"}>Menüler</Button>*/}
                {/*<Button style={{width:'125px'}} onClick={() => onPersonnelClick(restaurant.id)} color={"google plus"}>Personeller</Button>*/}
                <Button style={{width:'125px'}} onClick={() => onDetailClick(restaurant.id)} color={"linkedin"}>Detay</Button>
                <Button style={{width:'125px'}} onClick={() => onDeleteRestaurant(restaurant.id)} negative>Sil</Button>
            </TableCell>
        </Table.Row>
    ))
    return (
        <Table striped celled inverted size={"large"} style={{marginTop: 0, borderRadius: 0}}>
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
