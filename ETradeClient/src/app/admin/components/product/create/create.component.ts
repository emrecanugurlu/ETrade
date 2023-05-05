import { Component } from '@angular/core';
import { ProductCreate } from '../../../../contracts/product-create';
import { ProductServiceService } from '../../../../services/model/product-service.service';


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent {
  productService: ProductServiceService
  constructor(productService: ProductServiceService) {
    this.productService = productService
  }

  createProduct(productName: HTMLInputElement, productDescription : HTMLTextAreaElement, productStock: HTMLInputElement, productPrice: HTMLInputElement) {
    console.log("tetiklendi")
    var product: ProductCreate = new ProductCreate()
    product.name = productName.value
    product.price = parseInt(productPrice.value)
    product.description = productDescription.value
    product.stock = parseFloat(productStock.value)
    this.productService.CreateProduct(product)
  }
}
