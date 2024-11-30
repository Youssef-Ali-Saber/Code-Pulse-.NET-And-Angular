import { Component, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CategoryRequest } from '../Models/category-request.model';
import { CategoryService } from '../services/category.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css',
})
export class AddCategoryComponent {

  constructor(private categoryService: CategoryService, private router: Router) {}

  model: CategoryRequest = { name: '', urlHandle: '' };

  private addCategorySubscription?: Subscription;

  onFormSubmit() {
    this.addCategorySubscription = this.categoryService
      .addCategory(this.model)
      .subscribe({ next :() => {
        console.log('Category added successfully');
        this.router.navigate(['/admin/categories']);
      },
    error: (error) => {
      console.error('Error adding category', error);
      alert('Error adding category');
    }},
    );
  }

  ngOnDestroy(): void {
    this.addCategorySubscription?.unsubscribe();
  }

}
