import React from "react";
import {Button, Icon, Table} from "semantic-ui-react";

function ListPersonnel({personnelList,onAddPersonnel}){

    return (
        <Table striped celled inverted size={"large"} style={{marginTop: 0, borderRadius: 0}}>
            <Table.Header>
                <Table.Row>
                    <Table.HeaderCell>İsim</Table.HeaderCell>
                    <Table.HeaderCell>Soyisim</Table.HeaderCell>
                    <Table.HeaderCell>Email</Table.HeaderCell>
                    <Table.HeaderCell>Kullanıcı Adı</Table.HeaderCell>
                    <Table.HeaderCell>İşlemler</Table.HeaderCell>
                </Table.Row>
            </Table.Header>

            <Table.Body>
                {/*{mapped}*/}
            </Table.Body>
            <Table.Footer fullWidth>
                <Table.Row>
                    <Table.HeaderCell colspan='5'>
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
