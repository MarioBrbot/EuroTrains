import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';
import { TrainsService } from './../api/services/trains.service';
import { TrainsRm } from '../api/models'

@Component({
  selector: 'app-book-trains',
  templateUrl: './book-trains.component.html',
  styleUrls: ['./book-trains.component.css']
})
export class BookTrainsComponent implements OnInit {

  trainId: string = 'not loaded';
  train: TrainsRm = {}

  constructor(private route: ActivatedRoute,
    private router: Router,
    private trainsService: TrainsService){ }

  ngOnInit(): void {
    this.route.paramMap
      .subscribe(p => this.findTrain(p.get("trainId")))
  }


  private findTrain = (trainId: string | null) => {
    this.trainId = trainId ?? 'not passed';

    this.trainsService.findTrains({ id: this.trainId })
      .subscribe(train => this.train = train,
        this.handleError)
  }

  private handleError = (err: any) => {

    if (err.Status == 404) {
      alert("Train not found!");
      this.router.navigate(['/search-flights'])
    }
    console.log("Response Error. Status: ", err.status);
    console.log("Response Error. Status Text: ", err.statusText);
    console.log(err)
  }
}
