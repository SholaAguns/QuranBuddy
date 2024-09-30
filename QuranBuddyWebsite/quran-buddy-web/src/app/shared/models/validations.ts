import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function rangeValidator(): ValidatorFn {
  return (formGroup: AbstractControl): ValidationErrors | null => {
    const rangeStart = formGroup.get('rangeStart')?.value;
    const rangeEnd = formGroup.get('rangeEnd')?.value;

    if (rangeStart !== null && rangeEnd !== null && rangeEnd < rangeStart) {
      return { rangeInvalid: true }; 
    }
    return null; 
  };
}
