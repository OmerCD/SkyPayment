import React from 'react'
import { Card } from 'semantic-ui-react';
import MenuItem from './MenuItem';

function MenuList({menuItems, onMenuSelected}) {

    return (
        <Card.Group>
            {menuItems.map(menuItem =>
                    <MenuItem
                        key={menuItem.id}
                        description={menuItem.description}
                        subTitle={menuItem.subTitle}
                        title={menuItem.title}
                        onclick={()=> onMenuSelected(menuItem.id)}
                    />
                )}
        </Card.Group>
    )
}

export default MenuList;