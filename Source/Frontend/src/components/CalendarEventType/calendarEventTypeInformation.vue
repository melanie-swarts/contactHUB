<template>
  <div>
    <div class="box-form">
      <v-form ref="form" v-model="valid" lazy-validation>
        <v-container>
          <v-row>
            <v-col cols="12" md="12" sm="12">
              <v-text-field
                v-model="calendarEventType.EventTypeName"
                :rules="nameRules"
                :disabled="!newCalendarEventType"
                label="Name"
                @input="updateCalendarEventType"
              />
            </v-col>
          </v-row>
        </v-container>
        <v-container>
          <v-row>
            <v-col cols="3" md="3" sm="12">
              <color-drop-down
                :calendar-event-type="calendarEventType"
                :object-array="items"
                @set-color="setCalendarEventTypeColor($event)" />
            </v-col>
            <v-spacer/>

            <v-col cols="6">
              <v-card class="elevation-0">
                <v-card-title>Options</v-card-title>
                <v-divider/>
                <v-card-subtitle class="pb-0 ma-0"><v-checkbox
                  :disabled="!calendarEventType.Enabled"
                  v-model="calendarEventType.Enabled"
                  label="Enabled"
                  class="small-checkbox"
                /></v-card-subtitle>
              </v-card>
            </v-col>
          </v-row>
        </v-container>

      </v-form>
    </div>
  </div>
</template>
<script>

import Rules from '@/store/modules/rules.js'
import ColorDropDown from '@/components/Lists/ColorDropDown.vue'
import ColorList from '@/components/Lists/colorList.vue'
import { ChartColors } from '@/store/modules/enums'

export default {
  components: {
    ColorDropDown, ChartColors, ColorList
  },
  inheritAttrs: false,
  props: {
    calendarEventType: {
      type: Object,
      default: null
    },
    newCalendarEventType: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      swatches: [
        ['#E57373', '#F06292', '#BA68C8'],
        ['#9575CD', '#7986CB', '#64B5F6'],
        ['#FF8A65', '#90A4AE', '#4DB6AC'],
        ['#81C784', '#AED581', '#DCE775'],
        ['#FFF176', '#FFD54F', '#FFB74D']
      ],
      showColorPicker: false,
      items: ChartColors,
      valid: true,
      eventTypeName: '',
      nameRules: Rules.nameRules,
      enabled: 'True',
      selectedColor: 'Black'
    }
  },
  created() {
    this.setCalendarEventTypeEnabled()
    this.enabled = this.calendarEventType.Enabled
    this.newCalendarEventType = this.calendarEventType.EventTypeName === ''
  },
  methods: {
    setCalendarEventTypeEnabled() {
      if (this.calendarEventType.Enabled === undefined || this.calendarEventType.Enabled === null) {
        this.calendarEventType.Enabled = 'True'
      }
    },
    updateCalendarEventType() {
      this.$emit('calendarEventType:change', this)
    },
    setCalendarEventTypeColor(color) {
      this.selectedColor = color
      this.calendarEventType.Color = color
    }
  }
}
</script>

<style>
  .small-checkbox {
    padding: 0px;
    margin: 0px;
    height: 1.5rem;
  }
  .small-checkbox .v-label {
    font-size: 1rem;
    font-weight: 400;
  }
</style>
