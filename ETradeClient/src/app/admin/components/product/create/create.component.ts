import {Component, EventEmitter, Output} from '@angular/core';
import { ProductCreate } from '../../../../contracts/product_create';
import {ProductService} from "../../../../services/model/product.service";


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent {
  productService: ProductService
  constructor(productService: ProductService) {
    this.productService = productService
  }

  @Output() createProductEvent : EventEmitter<any> = new EventEmitter<any>()

  createProduct(productName: HTMLInputElement, productDescription : HTMLTextAreaElement, productStock: HTMLInputElement, productPrice: HTMLInputElement) {
    console.log("tetiklendi")
    var product: ProductCreate = new ProductCreate()
    product.name = productName.value
    product.price = parseInt(productPrice.value)
    product.description = productDescription.value
    product.stock = parseFloat(productStock.value)
    this.productService.createProduct(product,() => {
      this.createProductEvent.emit(product)
    })
  }
}
