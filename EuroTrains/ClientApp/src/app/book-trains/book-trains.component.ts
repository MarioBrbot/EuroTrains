import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';
import { TrainsService } from './../api/services/trains.service';
import { BookDto, TrainsRm } from '../api/models'
import { AuthService } from '../auth/auth.service';
import { FormBuilder, Validators } from '@angular/forms';


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
    private trainsService: TrainsService,
    private authService: AuthService,
    private fb: FormBuilder) { }


  form = this.fb.group({
    number: [1, Validators.compose([Validators.required, Validators.min(1), Validators.max(254)])]
  })

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
      this.router.navigate(['/search-trains'])
    }

    if (err.status == 409) {
      console.log("err: " + err);
      alert(JSON.parse(err.error).message)
    }

    console.log("Response Error. Status: ", err.status);
    console.log("Response Error. Status Text: ", err.statusText);
    console.log(err)
  }

  book() {
    if (this.form.invalid)
      return;

    console.log(`Booking ${this.form.get('number')?.value} passengers for the train: ${this.train.id}`)

    const booking: BookDto = {
      trainId: this.train.id,
      passengerEmail: this.authService.currentUser?.email,
      numberOfSeats: this.form.get('number')?.value as number
    }

    this.trainsService.bookTrains({ body: booking })
      .subscribe(_ => this.router.navigate(['/my-booking']),
        this.handleError)
  }

  get number() {
    return this.form.controls.number
  }
}
