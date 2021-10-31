const rules = {
  requiredRules: [
    v => !!v || 'Field is required'
  ],
  nameRules: [
    v => !!v || 'Name is required'
  ],
  textRules: [
    v => !!v || 'Field is required'
  ],
  descriptionRules: [
    v => !!v || 'Description is required'
  ],
  commentRules: [
    v => !!v || 'Comment is required'
  ],
  addressRules: [
    v => !!v || 'Address is required'
  ],
  emailRules: [
    v => !!v || 'Email is required',
    v => /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || 'E-mail must be valid'
  ],
  contactNumberRules: [
    v => !!v || 'Contact number is required',
    v => {
      if (!isNaN(parseFloat(v)) && v.length === 10 && v <= 9999999999) return true
      return 'Contact number has to be 10 digits long'
    }
  ],
  cellphoneRules: [
    v => !!v || 'Cellphone number is required',
    v => {
      if (!isNaN(parseFloat(v)) && v.length === 10 && v <= 9999999999) return true
      return 'Cellphone number has to be 10 digits long'
    }
  ],
  phoneRules: [
    v => !!v || 'Phone number is required',
    v => {
      if (!isNaN(parseFloat(v)) && v.length === 10 && v <= 9999999999) return true
      return 'Number has to be 10 digits long'
    }
  ],
  idNumberRules: [
    v => !!v || 'ID Number is required',
    v => {
      if (!isNaN(parseFloat(v)) && v.length === 13) return true
      return 'ID Number has to be 13 digits long'
    }
  ],
  calendarEventTypeRules: [
    v => !!v || 'Calendar event type is required',
    v => {
      if (v !== undefined && v !== null && v.Name !== undefined) return true
      return 'Calendar event type is required'
    }
  ],
  startTimeRules: [
    v => !!v || 'Start time is required'
  ],
  endTimeRules: [
    v => !!v || 'End time is required'
  ],
  startDateRules: [
    v => !!v || 'Start date is required'
  ],
  endDateRules: [
    v => !!v || 'End date is required'
  ],
  untilDateRules: [
    v => !!v || 'Until date is required'
  ],
  auditStatusTypeRules: [
    v => !!v || 'Audit Status Type is required'
  ],
  auditTypeRules: [
    v => !!v || 'Audit Type is required'
  ],
  auditorRules: [
    v => !!v || 'Auditor is required'
  ],
  regAuthRules: [
    v => !!v || 'Registering Authority is required'
  ],
  inspectorRules: [
    v => {
      if (v !== undefined && v !== '') return true
      return 'Inspector / Auditor is required'
    }
  ]
}
export default rules
