import { Checkbox, FormControlLabel, FormGroup } from "@mui/material";
import React, { useState } from "react";

interface Props {
  items: string[];
  checked?: string[];
  onChange: (items: string[]) => void;
}

const CheckBoxButton: React.FC<Props> = (props: Props) => {
  const { items, checked, onChange } = props;
  const [checkedItems, setCheckedItems] = useState(checked || []);

  const handleChecked = (value: string) => {
    const currentIndex = checkedItems.findIndex((item) => item === value);
    let newCheckedItems: string[] = [];
    if (currentIndex === -1) {
      newCheckedItems = [...checkedItems, value];
    } else {
      newCheckedItems = checkedItems.filter((item) => item !== value);
    }
    setCheckedItems(newCheckedItems);
    onChange(newCheckedItems);
  };
  return (
    <FormGroup>
      {items.map((item) => (
        <FormControlLabel
          key={item}
          control={
            <Checkbox
              checked={checkedItems.indexOf(item) !== -1}
              onClick={() => handleChecked(item)}
            />
          }
          label={item}
        />
      ))}
    </FormGroup>
  );
};

export default CheckBoxButton;
