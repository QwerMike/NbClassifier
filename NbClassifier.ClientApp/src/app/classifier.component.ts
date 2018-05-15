import { Component, Input  } from '@angular/core';

import { ClassifierService } from './classifier.service';

@Component({
  selector: 'classifier',
  templateUrl: './classifier.component.html',
  providers: [ClassifierService]
})
export class ClassifierComponent {

  @Input() review: string;
  reviewCategory: string;
  color: string;

  constructor(private classifierService: ClassifierService) { }

  classifyReview(): void {
    this.classifierService.classifyReview(this.review)
      .then(category => {
        this.reviewCategory = category;
        this.color = category == 'Positive' ? 'w3-teal' : 'w3-red';
        document.getElementById('modalReviewCategory')
          .style.display ='block';
      });
  }
}
