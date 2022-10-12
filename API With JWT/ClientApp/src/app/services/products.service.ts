import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
// url:"https://fakestoreapi.com/products"
  constructor(private http:HttpClient) { }

  Getproducts(){
    return this.http.get('https://fakestoreapi.com/products')
  }
}
