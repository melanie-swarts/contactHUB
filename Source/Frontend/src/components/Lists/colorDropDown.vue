<template>
  <div>
    <v-select
      v-model="typeColor"
      :items="items"
      attach
      chips
      label="Color"
      @change="setColor()"
    >
      <template v-slot:selection="{ attrs, item, selected }">
        <v-chip
          v-if="item === Object(item)"
          v-bind="attrs"
          :color="`${item.Color} ${colorTint }`"
          :input-value="selected"
          label

          small>
          <span class="pr-2">{{ item.Name }}</span>
        </v-chip>
      </template>
      <template v-slot:item="{ item }" class="yellow">
        <v-chip
          :color="`${item.Color} ${colorTint }`"
          label
          small>
          {{ item.Name }}
        </v-chip>
      </template>
    </v-select>
  </div>
</template>

<script>

import { CalendarEventTypeColors } from '@/store/modules/enums.js'
export default {
  components: { CalendarEventTypeColors },
  props: {
    calendarEventType: {
      type: Object,
      default: null
    },
    selectedColor: {
      type: Object,
      default: null
    },
    objectArray: {
      type: Object,
      default: null
    }
  },
  data() {
    return {
      colorTint: 'lighten-4',
      items: CalendarEventTypeColors,
      typeColor: this.calendarEventType.Color,
      values: this.getObjectArrayValues()
    }
  },
  methods: {
    getObjectArrayKeys() {
      var keys = []
      for (var key in this.objectArray) {
        keys.push(key.toUpperCase())
      }
      return keys
    },
    getObjectArrayValues() {
      var values = Object.values(this.objectArray)
      return values
    },
    setColor() {
      this.typeColor.Color = this.typeColor.Color + ' ' + this.colorTint
      this.$emit('set-color', this.typeColor)
    }
  }
}
</script>
