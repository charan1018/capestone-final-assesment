import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: any = [];

  constructor(private ProductService: ProductService) { }

  ngOnInit(): void {
    this.ProductService.getProducts().subscribe(data => {
      this.products = data;
    });
  }

}
