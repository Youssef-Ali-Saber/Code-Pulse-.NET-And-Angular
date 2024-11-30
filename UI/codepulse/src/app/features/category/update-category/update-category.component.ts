import { Component } from '@angular/core';
import { CategoryRequest } from '../Models/category-request.model';
import { FormsModule } from '@angular/forms';
import { CategoryService } from '../services/category.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-category',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './update-category.component.html',
  styleUrl: './update-category.component.css',
})
export class UpdateCategoryComponent {
  model!: CategoryRequest;

  id: string | null = null;

  constructor(
    private categoryService: CategoryService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe((params) => {
      this.id = params.get('id');});
      
    if (this.id) {
      this.categoryService.getCategoryById(this.id).subscribe((category) => {
        this.model = category;
      });
    }
  }

  onFormSubmit() {
    if (this.id) {
      this.categoryService
        .updateCategory(this.id, this.model)
        .subscribe(() => {
          console.log('Category updated successfully');
          this.router.navigate(['/admin/categories']);
        });
    }
  }

  deleteCategory(id: string) {
    if (confirm('Are you sure you want to delete this category?')) {
      this.categoryService.deleteCategory(id).subscribe({
        next: () => {
          this.router.navigate(['/admin/categories']);
        },
        error: (error) => {
          console.error(
            'Error deleting category',
            error.error
          );
          alert('Error deleting category');
        },
      });
    }
  }
}
