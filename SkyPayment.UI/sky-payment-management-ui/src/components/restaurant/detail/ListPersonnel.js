import React from "react";
import {Button, Icon, Table} from "semantic-ui-react";

function ListPersonnel({personnelList,onAddPersonnel}){
const mapped = personnelList.map(personnel => (
    <Table.Row>
        <Table.Cell>{personnel.name}</Table.Cell>
        <Table.Cell>{personnel.lastName}</Table.Cell>
        <Table.Cell>{personnel.email}</Table.Cell>
        <Table.Cell>{personnel.userName}</Table.Cell>
        <Table.Cell>{personnel.restaurant}</Table.Cell>
        <Table.Cell>
            <Button floated={"right"} color={"red"}>Sil</Button>
            <Button floated={"right"} color={"green"}>Düzenle</Button>
        </Table.Cell>
    </Table.Row>
))
    return (
        <Table striped celled inverted size={"large"} style={{marginTop: 0, borderRadius: 0}}>
            <Table.Header>
                <Table.Row>
                    <Table.HeaderCell>İsim</Table.HeaderCell>
                    <Table.HeaderCell>Soyisim</Table.HeaderCell>
                    <Table.HeaderCell>Email</Table.HeaderCell>
                    <Table.HeaderCell>Kullanıcı Adı</Table.HeaderCell>
                    <Table.HeaderCell>Restoran</Table.HeaderCell>
                    <Table.HeaderCell>İşlemler</Table.HeaderCell>
                </Table.Row>
            </Table.Header>

            <Table.Body>
                {mapped}
            </Table.Body>
            <Table.Footer fullWidth>
                <Table.Row>
                    <Table.HeaderCell colspan='6'>
                        <Button
                            floated='right'
                            labelPosition='left'
                            primary
                            icon
                            size={"small"}
                            onClick={onAddPersonnel}
                        >
                            <Icon name='plus'/>
                            Personel Ekle
                        </Button>
                    </Table.HeaderCell>
                </Table.Row>
            </Table.Footer>
        </Table>
    )
}

export default ListPersonnel;
