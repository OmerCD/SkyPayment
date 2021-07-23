export interface IMenuListProps {
    menus: IMenuListItem[]
}

export interface IMenuListItem {
    id: string;
    name: string;
    onSelected: (id: string) => void;
}

export interface MenuResponseModel {
    name: string;
    items: MenuItemResponse[];
    managementUserId: string;
}

export interface MenuItemResponse {
    name: string;
    price: number;
    ingredients: string;
    productContent: ProductContent;
}

export enum ProductContent {
    IsVegan = 1,
    IsDiabetic = 2,
    IsGlutenFree = 4,
    IsVegetarian = 8
}
