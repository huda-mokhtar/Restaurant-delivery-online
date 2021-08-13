import { OrderItem } from "./OrderItem";

export class Bill {
  constructor(public id: number, public name: string,
    public customerId: number, public OrderItems: Array<OrderItem>) { }
}
