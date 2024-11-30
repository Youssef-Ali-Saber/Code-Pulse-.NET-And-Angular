import { Component, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { categoryResponse } from '../Models/category-response.model';
import { CategoryService } from '../services/category.service';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-category-list',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css'],
})
export class CategoryListComponent {
  categories$?: Observable<categoryResponse[]>;

  constructor(private categoryService: CategoryService) {}

  ngOnInit() {
    this.categories$ = this.categoryService.getCategories();
  }

 
}
